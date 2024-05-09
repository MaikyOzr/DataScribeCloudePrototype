import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'; // ������������� BrowserRouter ��� ������������ ��������� �������������
import RegistrationForm from './RegistrationForm';
import LoginForm from './LoginForm';
import Home from './Home';

const App = () => {
    return (
        <div className="wrapper">
            <h1>Welcome to Your App</h1>
            {/* ������������� Switch ��� ����������� �� ���������� */}
            <Router> {/* ������� ������ ������������� ���������� BrowserRouter */}
                <Routes>
                    {/* Route ��� ����������� ���������� �� ��������� ������ */}
                    <Route path="/register" element={<RegistrationForm />} />
                    <Route path="/login" element={<LoginForm />} />
                    <Route path="/" element={<Home />} />
                </Routes>
            </Router>
        </div>
    );
}

export default App;
