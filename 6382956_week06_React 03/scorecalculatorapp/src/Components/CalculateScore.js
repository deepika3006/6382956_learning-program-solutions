// src/Components/CalculateScore.js
import React, { useState } from 'react';
import '../Stylesheets/mystyle.css';

function CalculateScore() {
  const [name, setName] = useState('');
  const [school, setSchool] = useState('');
  const [total, setTotal] = useState('');
  const [goal, setGoal] = useState('');
  const [average, setAverage] = useState(null);

  const handleSubmit = (e) => {
    e.preventDefault();
    const avg = parseFloat(total) / parseFloat(goal);
    setAverage(avg.toFixed(2));
  };

  const feedbackClass = average >= 75 ? 'high' : average >= 50 ? 'medium' : 'low';

  return (
    <div className="card">
      <h2>🎓 Score Calculator</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Student Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
          required
        />
        <input
          type="text"
          placeholder="School Name"
          value={school}
          onChange={(e) => setSchool(e.target.value)}
          required
        />
        <input
          type="number"
          placeholder="Total Marks"
          value={total}
          onChange={(e) => setTotal(e.target.value)}
          required
        />
        <input
          type="number"
          placeholder="Goal (Max Marks)"
          value={goal}
          onChange={(e) => setGoal(e.target.value)}
          required
        />
        <button type="submit">Calculate</button>
      </form>

      {average && (
        <div className={`result ${feedbackClass}`}>
          <p><strong>Name:</strong> {name}</p>
          <p><strong>School:</strong> {school}</p>
          <p><strong>Average Score:</strong> {average}</p>
        </div>
      )}
    </div>
  );
}

export default CalculateScore;
