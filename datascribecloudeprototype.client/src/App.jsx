import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'; // Використовуємо BrowserRouter для забезпечення контексту маршрутизації
import RegistrationForm from './RegistrationForm';
import LoginForm from './LoginForm';
import Home from './Home';

const App = () => {
    return (
        <div className="wrapper">
            <h1>Welcome to DataScribe</h1>
            {/* Використовуємо Switch для перемикання між маршрутами */}
            <Router> {/* Оточуємо дерево маршрутизації контекстом BrowserRouter */}
                <Routes>
                    {/* Route для відображення компонентів на відповідних шляхах */}
                    <Route path="/register" element={<RegistrationForm />} />
                    <Route path="/" element={<LoginForm />} />
                    <Route path="/home" element={<Home />} />
                </Routes>
            </Router>
        </div>
    );
}

export default App;
