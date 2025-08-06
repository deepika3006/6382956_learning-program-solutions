import React from "react";

function WelcomeButton() {
  function greet(message) {
    alert(message);
  }

  return (
    <div className="card">
      <h2>Welcome Message</h2>
      <button onClick={() => greet("Welcome to the Event Lab!")}>Say Welcome</button>
    </div>
  );
}

export default WelcomeButton;
