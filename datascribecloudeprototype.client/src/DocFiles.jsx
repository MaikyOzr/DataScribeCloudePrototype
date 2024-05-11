import React, { useState } from 'react';
import { Link } from 'react-router-dom';

const DocFiles = () => {
    const [selectedFile, setSelectedFile] = useState(null);

    const handleFileChange = (event) => {
        setSelectedFile(event.target.files[0]);
    };

    const handleUpload = async () => {
        if (!selectedFile) {
            alert('Please select a file');
            return;
        }

        const formData = new FormData();
        formData.append('file', selectedFile);

        try {
            const response = await fetch('https://localhost:7029/api/Doc/AddDocFiles', {
                method: 'POST',
                body: formData
            });
            if (response.ok) {
                alert('File uploaded successfully');
            } else {
                throw new Error('Failed to upload file');
            }
        } catch (error) {
            console.error('Error uploading file:', error);
            alert('Failed to upload file');
        }
    };

    return (
        <div>
            <input type="file" onChange={handleFileChange} style={{ display: 'none' }} ref={input => input && input.click()} />
            <Link to="#" className="upload-option" onClick={() => document.querySelector('input[type="file"]').click()}>
                <img src="doc-icon.png" alt="Document Icon" />
                <span>Upload Documents</span>
            </Link>
            <button onClick={handleUpload}>Upload</button>
        </div>
    );
};

export default DocFiles;
