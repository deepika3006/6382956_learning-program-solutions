import React from "react";
import Counter from "./components/Counter";
import WelcomeButton from "./components/WelcomeButton";
import SyntheticEvent from "./components/SyntheticEvent";
import CurrencyConvertor from "./components/CurrencyConvertor";
import "./App.css";

function App() {
  return (
    <div className="app">
      <h1>🎯 React Events Playground</h1>
      <Counter />
      <WelcomeButton />
      <SyntheticEvent />
      <CurrencyConvertor />
    </div>
  );
}

export default App;
