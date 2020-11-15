---
title: Function extraction with lambda expression
created: '2020-11-15T13:55:00.186Z'
modified: '2020-11-15T14:03:56.432Z'
---

# Function extraction with lambda expression

Goal to extra part of a code as seperate function
```[c++]
auto foo(int i, int j)
{
  int j = i + j;
  j++;
  return j;
}
```
 - declare a lamda, and move the part of code which need to be in seperate function.
```[c++]
auto foo(int i, int j)
{
  auto j = [&]() -> decltype(i) {
  int j = i + j;
  return j;
  }
  j++;
  return j;
}
```

 - remove lambda capture referance, so the compiler will indicate which parameter need to pass.
 ```[c++]
auto foo(int i, int j)
{
  auto j = [](int i, int j) -> decltype(i) {
  int j = i + j;
  return j;
  }
  j++;
  return j;
}
```

 - if lamdba function call work, them move it as seperate function.
  ```[c++]
auto cal(int i, int j) -> decltype(i) 
{
  int j = i + j;
  return j;
}

auto foo(int i, int j)
{
  auto j = cal(i,j);
  j++;
  return j;
}
```
