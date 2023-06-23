import React, { useState, useEffect } from 'react';
import RoomDetail  from '../RoomDetail/RoomDetail';
import './Dashboard.css';


const Dashboard = () => {
  const [startDate, setStartDate] = useState(new Date()); 
  const [selectedCell, setSelectedCell] = useState(null);
  const [refreshCount, setRefreshCount] = useState(0);
  const [existingRooms, setExistingRooms] = useState([]);


  useEffect(() => {
    const fetchRooms = async () => {
      try {
        const response = await fetch('https://localhost:7082/rooms');
        if (response.ok) {
          const rooms = await response.json();
          setExistingRooms(rooms);
        } else {
          console.error('Failed to fetch rooms:', response.status, response.statusText);
        }
      } catch (error) {
        console.error('Error fetching rooms:', error);
      }
    };

    fetchRooms();
  }, []);
  
  const handleDateChange = (event) => {
    const selectedDate = new Date(event.target.value);

    if (!isNaN(selectedDate)) {
    setStartDate(selectedDate);
  }
  };
  const handleCellClick = (date, roomNumber) => {
    setSelectedCell({ date, roomNumber });
  };
  const handleCloseRoomDetail = () => {
    setSelectedCell(null);
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
        const year = currentDate.getFullYear();
        const month = currentDate.getMonth() + 1; 
        const day = currentDate.getDate();
        const dayOfWeek = currentDate.toLocaleDateString('en-US', { weekday: 'long' });

        const formattedDate = `${month < 10 ? '0' : ''}${month}.${day}`;
        
          dates.push(
            <th key={i} className="date-cell">
              <div className="date-content">
                <span className="year">{year}</span>
                
                <span className="month-day">{formattedDate}</span>
                
                <span className="day-of-week">{dayOfWeek}</span>
              </div>
            </th>
          );

      currentDate.setDate(currentDate.getDate() + 1); 
    }

    return dates;
  };

  const renderRooms = () => {
    if (existingRooms.length === 0) {
      return null; 
    }
  
    return existingRooms.map((room) => (
      
      <tr key={room.roomNumber}>
        <td className="room-cell">{room.roomNumber}</td>
        {renderEmptyCells(room.roomNumber)}
        {console.log(room.roomNumber)}
      </tr>
    ));
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
     
      emptyCells.push(
        <td
          key={`${roomNumber}-${i}`}
          className="cell"
          onClick={() => handleCellClick(formattedDate, roomNumber)}
        ></td>
      );
    }

    return emptyCells;
  };
  const handleRefresh = () => {
    setRefreshCount(refreshCount + 1);
  };
  
  const renderHeaderCell = () => {
    return (
        <th className="header-cell">
        <div className="top-left-content">
          <button className="refresh-button" onClick={handleRefresh}>
            Refresh
          </button>
        </div>
      </th>
    );
  };

  useEffect(() => {
    console.log("Refresh");
  }, [refreshCount]);


  return (
    <div className="dashboard">
      <div className="date-picker-container">
        <div className="date-navigation">
      <button className="arrow-button" onClick={handlePreviousWeek}>
            &lt;
          </button>
          </div>
        <input
          type="date"
          className="date-picker"
          value={startDate.toISOString().split('T')[0]}
          onChange={handleDateChange}
        />
        <div className="date-navigation">
          
          <button className="arrow-button" onClick={handleNextWeek}>
            &gt;
          </button>
        </div>
      </div>

      <div className="table-container">
        <table className="table">
          <thead>
            <tr>
                {renderHeaderCell()}
              {renderDates()}
            </tr>
          </thead>
          <tbody>{renderRooms()}</tbody>
        </table>
      </div>
      {selectedCell && (
        <RoomDetail
          date={selectedCell.date}
          roomNumber={selectedCell.roomNumber}
          onClose={handleCloseRoomDetail}
        />
      )}
    </div>
  );
};

export default Dashboard;
