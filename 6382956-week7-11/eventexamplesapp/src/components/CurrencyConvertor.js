import React, { useState } from "react";

function CurrencyConvertor() {
  const [rupees, setRupees] = useState("");
  const [euros, setEuros] = useState("");

  const convert = (e) => {
    e.preventDefault();
    const rate = 0.011; // Example: 1 INR = 0.011 EUR
    const converted = parseFloat(rupees) * rate;
    setEuros(converted.toFixed(2));
  };

  return (
    <div className="card">
      <h2>INR to Euro Convertor</h2>
      <form onSubmit={convert}>
        <input
          type="number"
          placeholder="Enter INR"
          value={rupees}
          onChange={(e) => setRupees(e.target.value)}
        />
        <button type="submit">Convert</button>
      </form>
      {euros && <p>💶 Euros: €{euros}</p>}
    </div>
  );
}

export default CurrencyConvertor;
