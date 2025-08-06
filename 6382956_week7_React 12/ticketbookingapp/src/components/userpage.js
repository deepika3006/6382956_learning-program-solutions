import React from "react";

function UserPage() {
  function handleBooking(flight) {
    alert(`✅ Ticket booked for: ${flight}`);
  }

  return (
    <div className="card">
      <h2>Welcome! Book your flight:</h2>
      <ul>
        <li>
          Hyderabad → Delhi - 8:00 AM
          <button className="book-btn" onClick={() => handleBooking("Hyderabad → Delhi")}>
            Book Now
          </button>
        </li>
        <li>
          Chennai → Bangalore - 2:00 PM
          <button className="book-btn" onClick={() => handleBooking("Chennai → Bangalore")}>
            Book Now
          </button>
        </li>
        <li>
          Mumbai → Kolkata - 6:30 PM
          <button className="book-btn" onClick={() => handleBooking("Mumbai → Kolkata")}>
            Book Now
          </button>
        </li>
      </ul>
    </div>
  );
}

export default UserPage;
