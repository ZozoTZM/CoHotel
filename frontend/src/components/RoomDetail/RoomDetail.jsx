import React from 'react';
import './RoomDetail.css';

const RoomDetail = ({ date, roomNumber, onClose }) => {

    const fetchData = async () => {
        const response = await fetch('http://localhost:5000/rooms');
        const data = await response.json();
        console.log(data);
    
    }




  return (
    <div className="room-detail-overlay">
      <div className="room-detail-container">
        <div className="room-detail-header">
          <h2>Room Detail</h2>
          <button className="close-button" onClick={onClose}>
            Close
          </button>
        </div>
        <div className="room-detail-content">
          <p>Date: {date}</p>
          <p>Room Number: {roomNumber}</p>
        </div>
      </div>
    </div>
  );
};

export default RoomDetail;
