import React, { useState } from 'react';
import './RegistrationForm.css'; // Імпортуємо стилі для форми

const RegistrationForm = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState(null);

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const response = await fetch('https://localhost:7029/api/Registration/', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ email, password }),
            });

            const data = await response.json();

            if (!response.ok) {
                throw new Error(data.message || 'Registration failed');
            }

            // Тут ви можете виконати додаткову логіку після успішної реєстрації, наприклад, перенаправлення на іншу сторінку
            console.log('Registration successful');
        } catch (error) {
            setError(error.message);
        }
    };

    return (
        <div className="registration-form-container">
            <div className="registration-form">
                <h2>Registration Form</h2>
                <form onSubmit={handleSubmit}>
                    {error && <p className="error-message">{error}</p>}
                    <div className="form-group">
                        <label htmlFor="email">Email:</label>
                        <input
                            type="email"
                            id="email"
                            value={email}
                            onChange={(event) => setEmail(event.target.value)}
                            className="form-control"
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Password:</label>
                        <input
                            type="password"
                            id="password"
                            value={password}
                            onChange={(event) => setPassword(event.target.value)}
                            className="form-control"
                            required
                        />
                    </div>
                    <button type="submit" className="btn btn-purple">Register</button>
                </form>
            </div>
        </div>
    );
};

export default RegistrationForm;
