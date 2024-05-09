import React, { useState } from 'react';
import { Link } from 'react-router-dom';

const LoginForm = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState(null);

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const response = await fetch('https://localhost:7029/api/Registration/Login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ email: email, password: password }),
            });

            const data = await response.json();

            if (!response.ok) {
                throw new Error(data.message || 'Login failed');
            }

            console.log('Login successful');
            // Redirect to home page after successful login
            window.location.href = "/home"; // Assuming "/home" is your home page URL
        } catch (error) {
            setError(error.message);
            return;
        }
    };

    return (
        <div className="login-form-container">
            <div className="login-form">
                <h2>Login to your account</h2>
                <form onSubmit={handleSubmit} className="form-container">
                    {error && <p className="error-message">{error}</p>}
                    <div className="form_block">
                        <label htmlFor="email">Email:</label>
                        <input
                            type="email"
                            id="email"
                            value={email}
                            onChange={(event) => setEmail(event.target.value)}
                            onFocus={(event) => event.target.parentElement.classList.add('focused')}
                            onBlur={(event) => {
                                if (!event.target.value) {
                                    event.target.parentElement.classList.remove('focused');
                                }
                            }}
                            required
                        />
                    </div>
                    <div className="form_block">
                        <label htmlFor="password">Password:</label>
                        <input
                            type="password"
                            id="password"
                            value={password}
                            onChange={(event) => setPassword(event.target.value)}
                            onFocus={(event) => event.target.parentElement.classList.add('focused')}
                            onBlur={(event) => {
                                if (!event.target.value) {
                                    event.target.parentElement.classList.remove('focused');
                                }
                            }}
                            required
                        />
                    </div>
                    <button type="submit" className="btn-purple">Login</button>
                </form>
                <p>Don't have an account? <Link to="/register">Register</Link></p>
            </div>
        </div>
    );
};

export default LoginForm;
