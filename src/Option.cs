using System;

namespace FPCore {
  public struct Option<T> {
    public static Option<T> None => new Option<T>();

    public static implicit operator Option<T>(T value)
        => null == value ? None : new Option<T>(value);

    public R Match<R>(Func<R> None, Func<T, R> Some)
    => _isSome ? Some(_value) : None();
    
    Option(T value) {
      _value = value;
      _isSome = true;
    }

    readonly T _value;
    readonly Boolean _isSome;
  }
}
