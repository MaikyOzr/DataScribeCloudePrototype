import React, { useState, useEffect } from 'react';
import RegistrationForm from './Login';
import Notes from './Api'; // Помітили зміну імпорту

function App() {
    const [userData, setUserData] = useState([]);
    const [loadingUsers, setLoadingUsers] = useState(true);

    useEffect(() => {
        fetchUsers()
    }, []);

    const fetchUsers = async () => {
        try {
            const response = await fetch('https://localhost:7029/api/Registration/GetUsers');
            if (!response.ok) {
                throw new Error('Failed to fetch data');
            }

            const jsonData = await response.json();
            setUserData(jsonData);
            setLoadingUsers(false);
        } catch (error) {
            console.error('Error fetching data:', error);
            setLoadingUsers(false);
        }
    };

    return (
        <div>
            {loadingUsers ? (
                <p>Loading...</p>
            ) : (
                <>
                    <RegistrationForm />     
                </>
            )}
        </div>
    );
}

export default App;
