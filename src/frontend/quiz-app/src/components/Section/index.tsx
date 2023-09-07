import React from 'react';

const Section = (props: any) => {
  return <div className="section">{props.children}</div>;
};

export const SectionTitle = (props: any) => {
  return  <div className="section__title">{props.children}</div>;
};

export const SectionBody = (props: any) => {
  return <div className="section__body">{props.children}</div>;
};

export const SectionDescribe = (props: any) => {
    return <p className="section__describe">{props.children}</p>;
  };

export default Section;
