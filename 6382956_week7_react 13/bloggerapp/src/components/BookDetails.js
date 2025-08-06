import React from "react";

function BookDetails() {
  const books = [
    { id: 1, title: "React Made Easy", author: "John Doe" },
    { id: 2, title: "Mastering JS", author: "Jane Smith" },
    { id: 3, title: "CSS Secrets", author: "Lea Verou" },
  ];

  return (
    <div className="card">
      <h2>📘 Book Details</h2>
      <ul>
        {books.map((book) => (
          <li key={book.id}>
            <strong>{book.title}</strong> — {book.author}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default BookDetails;
