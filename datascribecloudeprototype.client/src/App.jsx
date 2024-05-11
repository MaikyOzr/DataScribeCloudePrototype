import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'; // ������������� BrowserRouter ��� ������������ ��������� �������������
import RegistrationForm from './RegistrationForm';
import LoginForm from './LoginForm';
import Home from './Home';
import MyAccPage from './MyAccPage';
import FilePage from './FilePage';
import DocFiles from './DocFiles';


const App = () => {
    return (
        <div className="wrapper">
            <h1>Welcome to DataScribe</h1>
            {/* ������������� Switch ��� ����������� �� ���������� */}
            <Router> {/* ������� ������ ������������� ���������� BrowserRouter */}
                <Routes>
                    {/* Route ��� ����������� ���������� �� ��������� ������ */}
                    <Route path="/register" element={<RegistrationForm />} />
                    <Route path="/" element={<LoginForm />} />
                    <Route path="/home" element={<Home />} />
                    <Route path="/myacc" element={<MyAccPage />} />
                    <Route path="/file" element={<FilePage />} />
                    <Route path="/doc" element={<DocFiles />} />
                </Routes>
            </Router>
        </div>
    );
}

export default App;
