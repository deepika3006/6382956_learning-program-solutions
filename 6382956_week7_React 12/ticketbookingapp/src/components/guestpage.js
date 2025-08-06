import React from "react";

function GuestPage() {
  return (
    <div className="card">
      <h2>Welcome, Guest 👋</h2>
      <p>You can browse available flights below:</p>
      <ul>
        <li>Hyderabad → Delhi - 8:00 AM</li>
        <li>Chennai → Bangalore - 2:00 PM</li>
        <li>Mumbai → Kolkata - 6:30 PM</li>
      </ul>
      <p>🔒 Please login to book your ticket.</p>
    </div>
  );
}

export default GuestPage;
