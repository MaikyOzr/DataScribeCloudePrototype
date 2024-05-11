import React, { useState, useEffect } from 'react';

const MyAccPage = () => {
    const [userData, setUserData] = useState(null);
    const [email, setEmail] = useState('');

    useEffect(() => {
        const fetchUserData = async () => {
            try {
                const response = await fetch(`https://localhost:7029/api/Registration/GetUser`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                });
                if (response.ok) {
                    const data = await response.json();
                    setUserData(data);
                } else {
                    throw new Error('Failed to fetch user data');
                }
            } catch (error) {
                console.error('Error fetching user data:', error);
            }
        };

        fetchUserData();
    }, [email]);

    return (

        <div className="myacc-page">
            <h2>My Account</h2>
            {userData ? (
                <div className="user-info">
                    <div>
                        <p>Email: {userData.email}</p>
                    </div>
                </div>
            ) : (
                <p>Loading...</p>
            )}
        </div>
    );
};

export default MyAccPage;
