import React, { useState } from "react";

function SignIn({ onSuccess }) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSignIn = (e) => {
    e.preventDefault();
    if (email && password) {
      localStorage.setItem("userEmail", email);
      localStorage.setItem("userPassword", password);
      alert("✅ Sign In successful! Please login.");
      onSuccess();
    } else {
      alert("❗ Please enter both email and password");
    }
  };

  return (
    <div className="card">
      <h2>📝 Sign In</h2>
      <form onSubmit={handleSignIn} className="login-form">
        <input
          type="email"
          placeholder="Enter new email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
        <input
          type="password"
          placeholder="Set password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />
        <button type="submit">Create Account</button>
      </form>
    </div>
  );
}

export default SignIn;
