import React, { useState, useEffect } from 'react';

function App() {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await fetch('https://localhost:7029/api/Notes/GetNotes');//для перевірки користувача встав /Registration/
            //const responseClone = response.clone();

            if (!response.ok) {
                throw new Error('Failed to fetch data');
            }

            const jsonData = await response.json();
            setData(jsonData);
            setLoading(false);
        } catch (error) {
            console.error('Error fetching data:', error);

            // Log the response body text if JSON parsing failed
            responseClone.text()
                .then(bodyText => {
                    console.log('Received the following instead of valid JSON:', bodyText);
                });

            setLoading(false);
        }
    };

    return (
        <div>
            <h1>This is DATASCRIBE BABY )</h1>
            {loading ? (
                <p>Loading...</p>
            ) : (
                <ul>
                    {data.map(item => (
                        <li key={item.id}>
                            {item.title} = {item.content}
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
}

export default App;
