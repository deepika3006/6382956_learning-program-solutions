import React, { useState } from "react";
import SignIn from "./components/signin";
import Login from "./components/login";
import GuestPage from "./components/guestpage";
import UserPage from "./components/userpage";
import "./App.css";

function App() {
  const [page, setPage] = useState("guest"); // guest | signin | login | user
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLoginSuccess = () => {
    setIsLoggedIn(true);
    setPage("user");
  };

  const handleLogout = () => {
    setIsLoggedIn(false);
    setPage("guest");
  };

  return (
    <div className="app">
      <h1>✈️ Flight Ticket Booking</h1>

      <div className="button-bar">
        {!isLoggedIn && (
          <>
            <button onClick={() => setPage("signin")}>Sign In</button>
            <button onClick={() => setPage("login")}>Login</button>
          </>
        )}
        {isLoggedIn && <button onClick={handleLogout}>Logout</button>}
      </div>

      <div className="content">
        {page === "signin" && <SignIn onSuccess={() => setPage("login")} />}
        {page === "login" && <Login onLoginSuccess={handleLoginSuccess} />}
        {page === "user" && <UserPage />}
        {page === "guest" && !isLoggedIn && <GuestPage />}
      </div>
    </div>
  );
}

export default App;
