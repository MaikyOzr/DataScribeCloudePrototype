import React, { useState } from 'react';
import { Link } from 'react-router-dom';

const RegistrationForm = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confPassword, setConfPassword] = useState('');
    const [error, setError] = useState(null);

    const handleSubmit = async (event) => {
        event.preventDefault();

        if (password !== confPassword) {
            setError("Passwords don't match");
            return;
        }

        try {
            const response = await fetch('https://localhost:7029/api/Registration/Register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ email: email, password: password, confPassword: confPassword }),
            });

            const data = await response.json();

            if (!response.ok) {
                throw new Error(data.message || 'Registration failed');
            }

            console.log('Registration successful');
        } catch (error) {
            setError(error.message);
            return;
        }

        // Redirect to home page after successful registration
        window.location.href = '/';
    };

    return (
        <div className="registration-form-container">
            <div className="registration-form">
                <h2>Create new account</h2>
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
                    <div className="form_block">
                        <label htmlFor="confPassword">Confirm Password:</label>
                        <input
                            type="password"
                            id="confPassword"
                            value={confPassword}
                            onChange={(event) => setConfPassword(event.target.value)}
                            onFocus={(event) => event.target.parentElement.classList.add('focused')}
                            onBlur={(event) => {
                                if (!event.target.value) {
                                    event.target.parentElement.classList.remove('focused');
                                }
                            }}
                            required
                        />
                    </div>
                    <button type="submit" className="btn-purple">Register</button>
                </form>
            </div>
        </div>
    );
};

export default RegistrationForm;
