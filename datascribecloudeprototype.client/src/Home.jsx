import React from 'react';
import { Link } from 'react-router-dom';
import './Home.css';

const Home = () => {
    return (
        <>
            Home page
            <div className="sidebar close">
                <div className="logo-details">
                    <i className='bx bxl-c-plus-plus'></i>
                    <span className="logo_name">DataScribe</span>
                </div>
                <ul className="nav-links">
                    <li className="personal">
                        <Link to="/myacc" className="nav-link">
                            <i className='bx bx-user'></i>
                            <span className="link_name">My Acc</span>
                        </Link>
                    </li>
                    <li className="uploaded">
                        <Link to="/file" className="nav-link">
                            <i className='bx bx-cloud-upload'></i>
                            <span className="link_name">Files</span>
                        </Link>
                    </li>
                    <li className="notes">
                        <a href="#">
                            <i className='bx bx-note'></i>
                            <span className="link_name">Notes</span>
                        </a>
                    </li>
                    {/* Додайте інші пункти меню тут */}
                </ul>
            </div>
            <section className="home-section">
                <div className="home-content">
                    <i className='bx bx-menu'></i>
                    <span className="text">Drop Down Sidebar</span>
                </div>
            </section>
            <div className="one"></div>
        </>
    );
}

export default Home;
