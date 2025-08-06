import React, { useState } from "react";

function Counter() {
  const [count, setCount] = useState(0);

  function increment() {
    setCount(prev => prev + 1);
    sayHello();
  }

  function sayHello() {
    console.log("Hello from React - counter updated!");
  }

  function decrement() {
    setCount(prev => prev - 1);
  }

  return (
    <div className="card">
      <h2>Counter: {count}</h2>
      <button onClick={increment}>➕ Increment</button>
      <button onClick={decrement}>➖ Decrement</button>
    </div>
  );
}

export default Counter;
