import React, { useState } from 'react';
import './App.css'; // Import external CSS

function App() {
  const [message, setMessage] = useState('');

  const handleClick = () => {
    setMessage('You just clicked the button! 🎉');
  };

  return (
    <div className="container">
      <h1 className="header">Welcome to the first session of React</h1>
      <button className="btn" onClick={handleClick}>Click Me</button>
      {message && <p className="message">{message}</p>}
    </div>
  );
}

export default App;
