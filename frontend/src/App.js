import { Route, Routes, useNavigate } from 'react-router-dom';
import React, { useState, useEffect } from 'react';
import './App.css';
import LandingPage from './components/landing-page/LandingPage';
import Dashboard from './components/dashboard/Dashboard';

function App() {
  const navigate = useNavigate();


  const handleLogin = () => {
    navigate('/dashboard', {replace: true});
  }
  return (
    <div className="App">
      <Routes>
          <Route path="/" element={<LandingPage handleLogin={handleLogin}/>}/>
          <Route path="/dashboard" element={<Dashboard/>}/>
      </Routes>
    </div>
  );
}

export default App;
