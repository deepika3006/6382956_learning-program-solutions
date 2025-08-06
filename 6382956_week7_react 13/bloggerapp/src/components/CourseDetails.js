import React from "react";

function CourseDetails() {
  const courses = [];

  // Conditional rendering using ternary operator
  return (
    <div className="card">
      <h2>🎓 Course Details</h2>
      {courses.length > 0 ? (
        <ul>
          {courses.map((course, index) => (
            <li key={index}>{course}</li>
          ))}
        </ul>
      ) : (
        <p>No courses available at the moment.</p>
      )}
    </div>
  );
}

export default CourseDetails;
