import React, { useState, useEffect } from 'react';
import LoginForm from './Login';
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
            <h1>This is DATASCRIBE BABY )</h1>
            {loadingUsers ? (
                <p>Loading...</p>
            ) : (
                <>
                    <div>
                        <h2>User Data</h2>
                        <LoginForm />
                        <ul>
                            {userData.map(user => (
                                <li key={user.id}>
                                    {user.email}
                                </li>
                            ))}
                        </ul>
                    </div>
                    <Notes/>
                </>
            )}
        </div>
    );
}

export default App;
