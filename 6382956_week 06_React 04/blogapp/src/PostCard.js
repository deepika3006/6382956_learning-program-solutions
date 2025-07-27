import React from 'react';
import './styles/blogstyle.css';

const PostCard = ({ title, body }) => {
  return (
    <div className="post-bubble">
      <div className="post-content">
        <h3>{title}</h3>
        <p>{body}</p>
      </div>
    </div>
  );
};

export default PostCard;
