import React from 'react';
import { Button } from 'antd';

import { Carousel } from 'antd';
import { Link, NavLink } from 'react-router-dom';
import { useAppSelector } from 'app/hooks';

const items = [
  {
    key: '1',
    title: 'Learn to Drive',
    content:
      'Aim to give you the knowledge to help you pass the exam easily with lessons and test sets based on the standards of the Ministry of Transport, which are updated regularly..',
  },
  {
    key: '2',
    title: 'Wonderful experience with study',
    content:
      'An vim odio ocurreret consetetur, justo constituto ex mea. Quidam facilisis vituperata pri ne. Id nostrud gubergren urbanitas sed, quo summo animal qualisque ut, cu nostro dissentias consectetuer mel. Ut admodum conceptam mei, cu eam tation fabulas abhorreant. His ex mandamus.',
  },
  {
    key: '3',
    title: 'The best web to increase your knowledged',
    content:
      'An vim odio ocurreret consetetur, justo constituto ex mea. Quidam facilisis vituperata pri ne. Id nostrud gubergren urbanitas sed, quo summo animal qualisque ut, cu nostro dissentias consectetuer mel. Ut admodum conceptam mei, cu eam tation fabulas abhorreant. His ex mandamus.',
  },
];

function AppHeroSlide() {
  const user = useAppSelector((state) => state.auth.user);

  return (
    <div id="hero" className="heroBlock">
      <Carousel>
        {items.map((item) => {
          return (
            <div key={item.key} className="container-fluid">
              <div className="content">
                <h3 style={{ color: 'white', fontSize: '45px' }}>{item.title}</h3>
                <p style={{ color: 'white', fontSize: '20px' }}>{item.content}</p>
                <div className="btnHolder">
                  <Button type="primary" size="large">
                    <NavLink to='#feature'>Learn More</NavLink>
                  </Button>
                  {!user && (
                    <Button size="large">
                      <Link to="/register">
                        <i className="fas fa-desktop"></i> Register
                      </Link>
                    </Button>
                  )}
                </div>
              </div>
            </div>
          );
        })}
      </Carousel>
    </div>
  );
}

export default AppHeroSlide;
