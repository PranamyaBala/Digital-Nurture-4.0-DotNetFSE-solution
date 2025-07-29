import React from 'react';
import './App.css';

const books = [
  { id: 101, bname: 'Master React', price: 670 },
  { id: 102, bname: 'Deep Dive into Angular 11', price: 800 },
  { id: 103, bname: 'Mongo Essentials', price: 450 },
];

const blogs = [
  { id: 1, title: 'React Learning', author:'Stephen Biz', desc: 'Welcome to learning React!' },
  { id: 2, title: 'Installation', author:'Schewdenier', desc: 'You can install react from npm' },
];

const courses = [
  { id: 201, cname: 'Angular', publishdate: '04-05-2021' },
  { id: 202, cname: 'React', publishdate: '06-03-2001' },
];

function BookDetails() {
  return (
    <div className="section">
      <h1>Book Details</h1>
      {books.map(book => (
        <div key={book.id}>
          <h2>{book.bname}</h2>
          <h4>Rs {book.price}</h4>
        </div>
      ))}
    </div>
  );
}

function BlogDetails() {
  const showBlogs = true; // conditional rendering
  return showBlogs ? (
    <div className="section">
      <h1>Blog Details</h1>
      {blogs.map(blog => (
        <div key={blog.id}>
          <h2>{blog.title}</h2>
          <h4>{blog.author}</h4>
          <p>{blog.desc}</p>
        </div>
      ))}
    </div>
  ) : <p>No Blogs to Show</p>;
}

function CourseDetails() {
  return (
    <div className="section">
      <h1>Course Details</h1>
      {courses.length > 0 ? (
        courses.map(course => (
          <div key={course.id}>
            <h2>{course.cname}</h2>
            <h4>{course.publishdate}</h4>
          </div>
        ))
      ) : (
        <p>No Courses Available</p>
      )}
    </div>
  );
}

function App() {
  return (
    <div className="container">
      <CourseDetails />
      <div className="divider"></div>
      <BookDetails />
      <div className="divider"></div>
      <BlogDetails />
    </div>
  );
}

export default App;
