import React from 'react';
import Home from './components/Home';
import About from './components/About';
import Contact from './components/Contact';

function App() {
  return (
    <div className="App">
      <h1 style={{ textAlign: 'center', color: '#2c3e50' }}>
        📚 Student Management Portal
      </h1>
      <Home />
      <About />
      <Contact />
    </div>
  );
}

export default App;
