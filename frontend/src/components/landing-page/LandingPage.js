import './LandingPage.css';
import React,{useState} from "react";

const LandingPage = (handleLogin) => {
    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");

    const handleSubmit = async (event) =>{
        event.preventDefault();
        handleLogin();
        /* const response = await fetch("https://localhost:3000/login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            credentials :'include',
            body:JSON.stringify({userName,password})
        });

        if(!response.ok){
            const message =`An error occurred: ${response.statusText}`;
            window.alert(message);
            return;
        }
        const data = await response.json();

        handleLogin(data.accesToken); */
    }

    return (
        <div className="landing-page-container">
      <div className="empty-column"></div>
      <div className="login-column">
      <form onSubmit={handleSubmit} className="login-form-container">
            <h2>Login to your account</h2>

            <div className="login-input-parent">
                <label htmlFor="username">Username</label>
                <input
                    type="userName"
                    value={userName}
                    onChange={(event) => setUserName(event.target.value)}
                    required
                />
            </div>

            <div className="login-input-parent">
                <label htmlFor="password">Password</label>
                <input
                    type="password"
                    value={password}
                    onChange={(event) => setPassword(event.target.value)}
                    required
                />
            </div>

            <button className="login-button" type="submit">Login</button>
        </form>
      </div>
      <div className="info-column">
        <div className="logo-container">
          <p className="logo-text">Co-Hotel</p>
        </div>
        <div className="sample-text">
          <p>
          "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
          </p>
        </div>
      </div>
      <div className='last-column'></div>
    </div>
    );
};

export default LandingPage;