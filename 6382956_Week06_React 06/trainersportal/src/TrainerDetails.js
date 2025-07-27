import React from 'react';
import { useParams } from 'react-router-dom';
import trainers from './TrainersMock';
import './styles/portal.css';

function TrainerDetails() {
  const { id } = useParams();
  const trainer = trainers.find((t) => t.id === parseInt(id));

  if (!trainer) {
    return <div className="page error">Trainer not found.</div>;
  }

  return (
    <div className="page">
      <h2>👤 Trainer Details</h2>
      <div className="trainer-card">
        <p><strong>Name:</strong> {trainer.name}</p>
        <p><strong>Email:</strong> {trainer.email}</p>
        <p><strong>Phone:</strong> {trainer.phone}</p>
        <p><strong>Stream:</strong> {trainer.stream}</p>
        <p><strong>Skills:</strong> {trainer.skills}</p>
      </div>
    </div>
  );
}

export default TrainerDetails;
