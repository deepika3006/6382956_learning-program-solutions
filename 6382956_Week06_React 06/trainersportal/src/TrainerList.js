import React from 'react';
import { Link } from 'react-router-dom';
import './styles/portal.css';

function TrainerList({ data }) {
  return (
    <div className="page">
      <h2>👨‍🏫 Meet Our Trainers</h2>
      <ul className="trainer-list">
        {data.map((trainer) => (
          <li key={trainer.id}>
            <Link to={`/trainer/${trainer.id}`}>{trainer.name}</Link>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default TrainerList;
