import React, { Component } from 'react';
import PostCard from './PostCard';
import './styles/blogstyle.css';

class Posts extends Component {
  constructor() {
    super();
    this.state = {
      posts: [],
      hasError: false
    };
  }

  componentDidMount() {
    this.fetchPosts();
  }

  fetchPosts = () => {
    fetch('https://jsonplaceholder.typicode.com/posts?_limit=6')
      .then((res) => res.json())
      .then((data) => this.setState({ posts: data }))
      .catch((err) => this.setState({ hasError: true }));
  };

  componentDidCatch(error, info) {
    alert('Something went wrong while displaying posts.');
    console.error(error, info);
  }

  render() {
    const { posts, hasError } = this.state;

    if (hasError) {
      return <p className="error-box">🚨 Could not load blog posts.</p>;
    }

    return (
      <div className="blog-wrapper">
        <header className="blog-header">
          <h1>🧠 BlogSphere</h1>
          <p>Where ideas take shape...</p>
        </header>
        <section className="post-grid">
          {posts.map((post) => (
            <PostCard key={post.id} title={post.title} body={post.body} />
          ))}
        </section>
      </div>
    );
  }
}

export default Posts;
