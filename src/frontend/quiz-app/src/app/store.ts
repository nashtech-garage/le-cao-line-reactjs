import { Action, combineReducers, configureStore, ThunkAction } from '@reduxjs/toolkit';
import { DEVELOPMENT } from 'constants/constants';
import { persistReducer, persistStore } from 'redux-persist';
import storage from 'redux-persist/lib/storage';
import authReducer from 'redux/features/authSlice';
import questionReducer from 'redux/features/questionSlice';
const reducers = combineReducers({
  auth: authReducer,
  questionRed: questionReducer,
});

const persistConfig = {
  key: 'root',
  storage,
  whitelist: ['auth', 'questionRed'],
};

const persistedReducer = persistReducer(persistConfig, reducers);
const store = configureStore({
  reducer: persistedReducer,
  devTools: process.env.NODE_ENV === DEVELOPMENT,
  middleware: (getDefaultMiddleware) => getDefaultMiddleware({ serializableCheck: false }),
});
let persistor = persistStore(store);

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
/* eslint import/no-anonymous-default-export: [2, {"allowObject": true}] */
export default { store, persistor };
