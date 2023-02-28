import React from 'react'
import "./ModalCreateHub.css"

function ModalCreateHub() {
  const handleSubmit = (data) => {
    console.log(data);
  };

  return (
    <div className="modalCreateHub">
      <h1>Create Hub</h1>
      <form onSubmit={handleSubmit} className="box">
        <input type="text" placeholder="Hub Name" />
        <input type="text" placeholder="Description" />
        <button type="submit">Create Hub</button>
      </form>
    </div>
  );
}

export default ModalCreateHub