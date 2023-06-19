import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Dashboard.css';

const Dashboard = () => {
  const [startDate, setStartDate] = useState(new Date()); 
  const navigate = useNavigate();

  
  const handleDateChange = (event) => {
    const selectedDate = new Date(event.target.value);
    setStartDate(selectedDate);
  };

  const handlePreviousWeek = () => {
    const previousWeek = new Date(startDate);
    previousWeek.setDate(previousWeek.getDate() - 7);
    setStartDate(previousWeek);
  };

  const handleNextWeek = () => {
    const nextWeek = new Date(startDate);
    nextWeek.setDate(nextWeek.getDate() + 7);
    setStartDate(nextWeek);
  };

  const renderDates = () => {
    const dates = [];
    const currentDate = new Date(startDate);

    for (let i = 0; i < 7; i++) {
      const formattedDate = currentDate.toLocaleDateString('en-US', {
        year: 'numeric',
        month: 'short',
        day: 'numeric',
      });
      dates.push(
        <th key={i} className="date-cell">
          {formattedDate}
        </th>
      );

      currentDate.setDate(currentDate.getDate() + 1); 
    }

    return dates;
  };

  const renderRooms = () => {
    const rooms = [];

    for (let i = 101; i <= 120; i++) {
      rooms.push(
        <tr key={i}>
          <td className="room-cell">{i}</td>
          {renderEmptyCells(i)}
        </tr>
      );
    }

    return rooms;
  };

  const renderEmptyCells = (roomNumber) => {
    const emptyCells = [];

    for (let i = 0; i < 7; i++) {
      const currentDate = new Date(startDate);
      currentDate.setDate(currentDate.getDate() + i);
      const formattedDate = currentDate.toLocaleDateString('en-US', {
        year: 'numeric',
        month: 'short',
        day: 'numeric',
      });

      const handleCellClick = () => {
        navigate(`/room-detail/${formattedDate}/${roomNumber}`);
      };

      emptyCells.push(
        <td key={i} className="empty-cell" onClick={handleCellClick}></td>
      );
    }

    return emptyCells;
  };

  return (
    <div className="dashboard">
      <div className="date-picker-container">
        <input
          type="date"
          className="date-picker"
          value={startDate.toISOString().split('T')[0]}
          onChange={handleDateChange}
        />
        <div className="date-navigation">
          <button className="arrow-button" onClick={handlePreviousWeek}>
            &lt;
          </button>
          <button className="arrow-button" onClick={handleNextWeek}>
            &gt;
          </button>
        </div>
      </div>

      <div className="table-container">
        <table className="table">
          <thead>
            <tr>
              <th></th> 
              {renderDates()}
            </tr>
          </thead>
          <tbody>{renderRooms()}</tbody>
        </table>
      </div>
    </div>
  );
};

export default Dashboard;
