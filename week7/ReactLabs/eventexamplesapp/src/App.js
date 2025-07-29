import React, { useState } from 'react';
import './App.css';
import CurrencyConvertor from './CurrencyConvertor';

function App() {
  const [counter, setCounter] = useState(0);

  // Multiple method handler for increment
  const handleIncrement = () => {
    incrementCounter();
    sayHello();
  };

  const incrementCounter = () => {
    setCounter(prev => prev + 1);
  };

  const decrementCounter = () => {
    setCounter(prev => prev - 1);
  };

  const sayHello = () => {
    console.log("Hello! This is a static message.");
  };

  const sayWelcome = (message) => {
    alert(message);
  };

  const handlePress = (event) => {
    alert("I was clicked");
  };

  return (
    <div className="App">
      <h1>Event Handling Examples</h1>

      <h2>Counter: {counter}</h2>
      <button onClick={handleIncrement}>Increment</button>
      <br/>
      <button onClick={decrementCounter}>Decrement</button>
      <br />
      <button onClick={() => sayWelcome("Welcome!")}>Say Welcome</button>
      <br />
      <button onClick={handlePress}>Click Me</button>

      <hr />
      <CurrencyConvertor />
    </div>
  );
}

export default App;
