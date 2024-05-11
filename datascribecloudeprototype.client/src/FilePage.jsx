import React from 'react';
import { Link } from 'react-router-dom';
import DocFiles from './DocFiles';

const FilePage = () => {
    return (
        <div>
            <h1>Upload Files</h1>
            <div className="upload-options">
                <Link to="/doc" className="upload-option">
                    <img src="doc-icon.png" alt="Document Icon" />
                    <span>Upload Documents</span>
                </Link>
                <Link to="/image" className="upload-option">
                    <img src="image-icon.png" alt="Image Icon" />
                    <span>Upload Images</span>
                </Link>
                <Link to="/pdf" className="upload-option">
                    <img src="pdf-icon.png" alt="PDF Icon" />
                    <span>Upload PDFs</span>
                </Link>
                <Link to="/pptx" className="upload-option">
                    <img src="pptx-icon.png" alt="PPTX Icon" />
                    <span>Upload PPTX</span>
                </Link>
            </div>
        </div>
    );
};

export default FilePage;
