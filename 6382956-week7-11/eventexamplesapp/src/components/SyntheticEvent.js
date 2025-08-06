import React from "react";

function SyntheticEvent() {
  function handleClick(e) {
    e.preventDefault();
    alert("I was clicked using Synthetic Event!");
  }

  return (
    <div className="card">
      <h2>Synthetic Event</h2>
      <button onClick={handleClick}>Click Me</button>
    </div>
  );
}

export default SyntheticEvent;
