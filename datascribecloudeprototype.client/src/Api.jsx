import React, { useState } from 'react';

function Notes() {
    const [noteData, setNoteData] = useState([]);
    const [loadingNotes, setLoadingNotes] = useState(true);

    const fetchNotes = async () => {
        try {
            const response = await fetch('https://localhost:7029/api/Notes/GetNotes');
            if (!response.ok) {
                throw new Error('Failed to fetch data');
            }

            const jsonData = await response.json();
            setNoteData(jsonData);
            setLoadingNotes(false);
        } catch (error) {
            console.error('Error fetching data:', error);
            setLoadingNotes(false);
        }
    };

    return (
        <div>
            <h1>Notes</h1>
            {loadingNotes ? (
                <p>Loading...</p>
            ) : (
                <ul>
                    {noteData.map(note => (
                        <li key={note.id}>
                            {note.title} = {note.content}
                        </li>
                    ))}
                </ul>
            )}
        </div>
    )
}

export default Notes;

            