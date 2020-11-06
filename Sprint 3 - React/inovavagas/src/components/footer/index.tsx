import React from "react";
import './style.css';
import facebook from '../../assets/images/facebook_Branco.png';
import instagram from '../../assets/images/insta_Branco.png';
import twitter from '../../assets/images/tt_Branco.png';

const Footer = () => {
    return (
        <div className="footer">
            <div className="box-content">
                <div className="box-container">
                    <p className="contato">Contato:</p>
                    <p className="info">senaiInova@email.com</p>
                    <p className="info">11 45567821</p>
                </div>
                <div className="logos-container">
                    <img src={facebook} alt="link facebook" width="30px"/>
                    <img src={instagram} alt="link instagram" width="30px"/>
                    <img src={twitter} alt="link twitter" width="30px"/>
                </div>
            </div>
        </div>
    )
}

export default Footer;