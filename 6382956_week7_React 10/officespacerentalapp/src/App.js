import React, { useState } from "react";
import "./App.css";

const officeList = [
  {
    name: "Cyber Heights",
    rent: 55000,
    address: "123 Tech Park, Hyderabad",
    image: "https://via.placeholder.com/400x200?text=Cyber+Heights"
  },
  {
    name: "Tech Tower",
    rent: 72000,
    address: "456 IT Road, Bengaluru",
    image: "https://via.placeholder.com/400x200?text=Tech+Tower"
  },
  {
    name: "Startup Hub",
    rent: 48000,
    address: "789 Innovation Ave, Pune",
    image: "https://via.placeholder.com/400x200?text=Startup+Hub"
  }
];

function App() {
  const [searchTerm, setSearchTerm] = useState("");

  const filteredOffices = officeList.filter((office) =>
    office.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <main className="app-container">
      <header>
        <h1>🏢 Office Space Rental App</h1>
        <p className="subheading">Find your perfect workspace today!</p>
        <input
          type="text"
          placeholder="🔍 Search office by name..."
          className="search-box"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          aria-label="Search Office"
        />
      </header>
      <section>
        {filteredOffices.length === 0 ? (
          <p>No offices found for your search.</p>
        ) : (
          filteredOffices.map((office, index) => (
            <article className="card" key={index}>
              <img src={office.image} alt={`Office: ${office.name}`} />
              <div className="info">
                <h2>{office.name}</h2>
                <p><strong>📍 Address:</strong> {office.address}</p>
                <p>
                  <strong>💰 Rent:</strong>{" "}
                  <span className={office.rent < 60000 ? "low-rent" : "high-rent"}>
                    ₹{office.rent}
                  </span>
                </p>
              </div>
            </article>
          ))
        )}
      </section>
    </main>
  );
}

export default App;
