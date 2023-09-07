# Workshop Project: Quiz App

## Setup environment 

### 1. Setup ReactJS App via Create React App

> Link: https://create-react-app.dev/docs/getting-started/

### 2. Add SCSS support

```js
npm i --save-dev node-sass
npm install --save styled-components
```
Icon: https://react-icons.github.io/react-icons/icons?name=ai

### 3. Add react router V6

```
npm i --save react-router-dom
```

### 4. Add UI lib

```
npm i --save antd
https://ant.design/docs/react/introduce
```


## Tổ chức folder

```
src
|__ assets
|  |__ images
|  |__ icons
|
|__ sass
|
|__ routers
|__ models
|__ helper
|__ constants
|__ configs
|__ app
|__ api
|__ components (shared components)
|   |__ Header
|   |__ Footer
|   |__ ...
|
|__ features
  |__ Home
  | |__ components
  | |
  | |__ Login
  | |  |__ LoginSlice/ts
  | | 
  | |__ index.js
  |
  |__ QuestionManagement
    |__ index.tsx
    
```

## Tổ chức routing

- Sử dụng kĩ thuật lazy load components.
- Load theo features.
