import React from 'react';

const Heading = (props: any) => {
  return <div className="heading">{props.children}</div>;
};
export const HeadingSmall = (props: any) => {
  return <p className="heading__small">{props.children}</p>;
};

export const HeadingMedium = (props: any) => {
  return <p className="heading__medium">{props.children}</p>;
};

export const HeadingLarge = (props: any) => {
  return <p className="heading__large">{props.children}</p>;
};
export default Heading;
