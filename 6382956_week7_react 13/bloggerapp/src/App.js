import React, { useState } from "react";
import BookDetails from "./components/BookDetails";
import BlogDetails from "./components/BlogDetails";
import CourseDetails from "./components/CourseDetails";
import "./App.css";

function App() {
  const [activeComponent, setActiveComponent] = useState("book");

  // Using element variable for conditional rendering
  let content;
  if (activeComponent === "book") {
    content = <BookDetails />;
  } else if (activeComponent === "blog") {
    content = <BlogDetails />;
  } else {
    content = <CourseDetails />;
  }

  return (
    <div className="app">
      <h1>📚 BloggerApp</h1>
      <div className="button-bar">
        <button onClick={() => setActiveComponent("book")}>Book Details</button>
        <button onClick={() => setActiveComponent("blog")}>Blog Details</button>
        <button onClick={() => setActiveComponent("course")}>Course Details</button>
      </div>

      {/* Rendering content based on condition */}
      {content}
    </div>
  );
}

export default App;
