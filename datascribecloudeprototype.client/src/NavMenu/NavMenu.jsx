import React from 'react';
import { useState } from 'react'
import styles from "./NavMenu.css";

function NavMenu() {
    const [isActive, setIsActive] = useState(false);
    return (
        <div className="App">
            <header className="App-header">
                <nav className={`${styles.navbar}`}>
                    {/* logo */}
                    <a href='#home' className={`${styles.logo}`}>Dev. </a>
                    <ul className={`${styles.navMenu} ${isActive ? styles.active : ''}`}>
                        <li>
                            <h2>Navigation</h2>
                        </li>
                        <li>
                            <a href='#home' className={`${styles.navLink}`}>Home</a>
                        </li>
                        <li>
                            <a href='#catalog' className={`${styles.navLink}`}>Catalog</a>
                        </li>
                        <li>
                            <a href='#products' className={`${styles.navLink}`}>All products</a>
                        </li>
                        <li>
                            <a href='#contact' className={`${styles.navLink}`}>Contact</a>
                        </li>
                    </ul>
                </nav>
            </header>
        </div>
    );
}

export default NavMenu;