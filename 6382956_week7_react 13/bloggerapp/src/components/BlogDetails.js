import React from "react";

function BlogDetails() {
  const blogs = [
    { id: "b1", title: "Why React is Awesome", date: "2025-08-01" },
    { id: "b2", title: "Understanding Conditional Rendering", date: "2025-07-20" },
  ];

  return (
    <div className="card">
      <h2>✍️ Blog Details</h2>
      {blogs.length > 0 ? (
        <ul>
          {blogs.map((blog) => (
            <li key={blog.id}>
              <strong>{blog.title}</strong> — <em>{blog.date}</em>
            </li>
          ))}
        </ul>
      ) : (
        <p>No blogs available.</p>
      )}
    </div>
  );
}

export default BlogDetails;
