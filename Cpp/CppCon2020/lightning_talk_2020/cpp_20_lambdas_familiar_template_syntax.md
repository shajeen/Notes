# C++20 Lambdas: Familiar Template Syntax

video at [watch_me](https://www.youtube.com/watch?v=uOc6RPu9-CA&list=PLHTh1InhhwT7bZ9bfG3pIR6VVjXLrrUoP&index=11)

#### Generic lambdas c++14
```c++
auto something = [](auto &&x, auto &&y){
    something_else(std::forward<decltype>(x),std::forward<decltype>(y));
};
```

#### Familiar template syntax lambda c++20
```c++
auto something = []<class X, class Y>(X &&x, Y &&y){
    something_else(std::forward<X>(x),std::forward<Y>(y));
};
```

- makes deduction type much easier.