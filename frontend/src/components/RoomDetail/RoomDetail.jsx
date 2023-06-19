import React from 'react';
import './RoomDetail.css';

const RoomDetail = ({ date, roomNumber, onClose }) => {
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
