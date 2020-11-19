---
title: Template metaprograming
watched: '44:24/59:51'
---

# Template metaprograming

2014 - Dr Walter E.Brown. great tutorial about temaplate meta-programing.

## CppCon 2014: Walter E. Brown "Modern Template Metaprogramming: A Compendium, Part I"

**metaprogramming** - write or manipulate other programs or work at compile time that would other wise be done at runtime.

**C++ template metaprogramming** - use template instantiation to drive compile time evaluation.

  - to improve source code flexibility and runtime performance.
  - keep in mind, say NO to - mutability, virtual function, other RTTI.
  - put it simple.

example 1 - compile-time absolute value metafuntion

  ```
  template<int N>
  struct abs {
    static_assert(N != INT_MIN);
    static constexpr int value = (N<0)?-N:N; // return
  }
  ```

 - metafunction arg(s) are supplied as the template's arg(s)
 - "call" syntax is a request for the template published value.

```
 int const n = abs<n>::value
```

*C++11 constexpr function can be useful, but...*

```
constexpr int abs(int N) {return (N<0)?-N:N;}
```

usage is via familiar function call syntax

```
int const n = abs(n) // yields a compile-time constant
```

  - But, as struct metafunction offer us more tools,
    - public member type declaration(typedef, using)
    - public member data declaration (static const/constexpr, each init via a const expression).
    - public member templates, static_asserts and more.

**Compile time recursion**
primary template for gcd(m,n) metafunction,

```
template<unsinged M, unsinged N>
struct gcd {
  static int const value = gcd<N, M%N>::value;
}
```

much like pattern matching, this partial specialization recognizes the (base) case for gcd(m,0)

```
template<unsigned M>
struct gcd<M,0> {
  static_assert(M != 0);
  static int const value = M;
}
```

**metafunction can take a type as a parameter/args**
 - *sizeof* is a build-in type function

example: obtain the compile-time tank of an array type

```
// primary template handles scalar (non-array) types as base case
template<class T>
stuct rank { static size_t const value = 0u; };

// partial specialization recognizes any array type
template<clas U, size_t N>
struct rank<U[N]> {
  static size_t const value = 1u + rank<U>::value;
};
```

usage,

``` 
using array_t = int[10][20][30];
rank<array_t>::value; // yields 3u at compile time
```

**metafunction can also produce a type as its result**
 - example: remove a type's const-qualification
  - no real removal; give me the equivalent type without const

```
// primary template handles types that are not const-qualified
template<class T>
struct remove_const { using type = T; };

// partial specializations for const-qualified types
template<class U>
struct remove_const<U const> { using type = U;};

// Usage
remove_const<T>::type t; // ensure t has a mutable type
remove_const_t<T> t; // c++14 equivalent; more later
```

**C++11 library metafunction convention #1**

example: an identity metafunction
```
template<class T>
struct type_is { using type = T; };

// can apply to inheritance
// primary template handles types are not volitile-qualified
template<class T>
struct remove_volatile : type_is<T> {};

// partial specialization for volatile-qualified types
template<class U>
struct remove_volatile<U volatile> : type_is<U> {};
```

**Compile-time decision-making**
 - imagine a metafuncitn, IF/IF_t, to select one of two types,

     ```
     template<bool p, class T, class F?
     struct IF : type_is<-> {}; // p ? T : F
     ```

 - such a facility would let us write self-configuring code

     ```
     int const q = -;
     IF_t<(q<0), int, unsigned> k; // k declared to have 1 of these 2 int types
     IF_t<(q<0),F,G>{}(...) // instantiate and call 1 of these 2 function objects
     class D : public IF_t<(q<0), B1, B2> {...}; // inherit from 1 of these 2 base classes
     ```

*Behind the scenes of IF*
 
 - Straightforward to implement
 
 ```
 // primary template
 template<bool, class T, class> struct IF : type_is<T> {};

 // partial template function
 template<class T, class F>
 struct IF<false, T, F> : type_is<F>{};
 ```


