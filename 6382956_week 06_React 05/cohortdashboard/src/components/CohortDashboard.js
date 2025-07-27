// src/components/CohortDashboard.js
import React from 'react';
import styles from './CohortDetails.module.css';

const cohortData = [
  { id: 101, title: 'Full Stack Dev - React', mentor: 'Ananya Gupta', status: 'ongoing' },
  { id: 102, title: 'DevOps Accelerator', mentor: 'Jaydeep R.', status: 'completed' },
  { id: 103, title: 'Cloud Native Apps', mentor: 'Samar Sinha', status: 'ongoing' },
  { id: 104, title: 'Java Spring Track', mentor: 'Neha Patil', status: 'completed' }
];

const CohortDashboard = () => {
  return (
    <section className={styles.dashboardBackground}>
      <h2 style={{ textAlign: 'center', marginBottom: '30px', color: '#2c3e50' }}>
        🎓 Cohort Overview
      </h2>

      <div style={{ display: 'flex', flexWrap: 'wrap', gap: '15px', justifyContent: 'center' }}>
        {cohortData.map((item) => {
          const titleColor = item.status === 'ongoing' ? 'green' : 'blue';

          return (
            <div key={item.id} className={styles.box}>
              <h3 style={{ color: titleColor, marginBottom: '10px' }}>{item.title}</h3>
              <dl>
                <dt>Mentor</dt>
                <dd>{item.mentor}</dd>
                <dt>Status</dt>
                <dd>{item.status}</dd>
              </dl>
            </div>
          );
        })}
      </div>
    </section>
  );
};

export default CohortDashboard;
