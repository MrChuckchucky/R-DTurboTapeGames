using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
	public class LogEventRequest_action_endTurn : GSTypedRequest<LogEventRequest_action_endTurn, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_action_endTurn() : base("LogEventRequest"){
			request.AddString("eventKey", "action_endTurn");
		}
	}
	
	public class LogChallengeEventRequest_action_endTurn : GSTypedRequest<LogChallengeEventRequest_action_endTurn, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_action_endTurn() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "action_endTurn");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_action_endTurn SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
	}
	
	public class LogEventRequest_action_playCard : GSTypedRequest<LogEventRequest_action_playCard, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_action_playCard() : base("LogEventRequest"){
			request.AddString("eventKey", "action_playCard");
		}
	}
	
	public class LogChallengeEventRequest_action_playCard : GSTypedRequest<LogChallengeEventRequest_action_playCard, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_action_playCard() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "action_playCard");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_action_playCard SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
	}
	
	public class LogEventRequest_action_pullCard : GSTypedRequest<LogEventRequest_action_pullCard, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_action_pullCard() : base("LogEventRequest"){
			request.AddString("eventKey", "action_pullCard");
		}
	}
	
	public class LogChallengeEventRequest_action_pullCard : GSTypedRequest<LogChallengeEventRequest_action_pullCard, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_action_pullCard() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "action_pullCard");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_action_pullCard SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
	}
	
	public class LogEventRequest_action_pushCard : GSTypedRequest<LogEventRequest_action_pushCard, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_action_pushCard() : base("LogEventRequest"){
			request.AddString("eventKey", "action_pushCard");
		}
	}
	
	public class LogChallengeEventRequest_action_pushCard : GSTypedRequest<LogChallengeEventRequest_action_pushCard, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_action_pushCard() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "action_pushCard");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_action_pushCard SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
	}
	
	public class LogEventRequest_ChallengeTurnTaken : GSTypedRequest<LogEventRequest_ChallengeTurnTaken, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_ChallengeTurnTaken() : base("LogEventRequest"){
			request.AddString("eventKey", "ChallengeTurnTaken");
		}
	}
	
	public class LogChallengeEventRequest_ChallengeTurnTaken : GSTypedRequest<LogChallengeEventRequest_ChallengeTurnTaken, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_ChallengeTurnTaken() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "ChallengeTurnTaken");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_ChallengeTurnTaken SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
	}
	
	public class LogEventRequest_findMatch : GSTypedRequest<LogEventRequest_findMatch, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_findMatch() : base("LogEventRequest"){
			request.AddString("eventKey", "findMatch");
		}
	}
	
	public class LogChallengeEventRequest_findMatch : GSTypedRequest<LogChallengeEventRequest_findMatch, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_findMatch() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "findMatch");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_findMatch SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
	}
	
	public class LogEventRequest_Get_Pos : GSTypedRequest<LogEventRequest_Get_Pos, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_Get_Pos() : base("LogEventRequest"){
			request.AddString("eventKey", "Get_Pos");
		}
	}
	
	public class LogChallengeEventRequest_Get_Pos : GSTypedRequest<LogChallengeEventRequest_Get_Pos, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_Get_Pos() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "Get_Pos");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_Get_Pos SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
	}
	
	public class LogEventRequest_LOAD_PLAYER : GSTypedRequest<LogEventRequest_LOAD_PLAYER, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_LOAD_PLAYER() : base("LogEventRequest"){
			request.AddString("eventKey", "LOAD_PLAYER");
		}
	}
	
	public class LogChallengeEventRequest_LOAD_PLAYER : GSTypedRequest<LogChallengeEventRequest_LOAD_PLAYER, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_LOAD_PLAYER() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "LOAD_PLAYER");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_LOAD_PLAYER SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
	}
	
	public class LogEventRequest_SAVE_PLAYER : GSTypedRequest<LogEventRequest_SAVE_PLAYER, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_SAVE_PLAYER() : base("LogEventRequest"){
			request.AddString("eventKey", "SAVE_PLAYER");
		}
		public LogEventRequest_SAVE_PLAYER Set_XP( long value )
		{
			request.AddNumber("XP", value);
			return this;
		}			
		
		public LogEventRequest_SAVE_PLAYER Set_POS( string value )
		{
			request.AddString("POS", value);
			return this;
		}
		public LogEventRequest_SAVE_PLAYER Set_GOLD( long value )
		{
			request.AddNumber("GOLD", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_SAVE_PLAYER : GSTypedRequest<LogChallengeEventRequest_SAVE_PLAYER, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_SAVE_PLAYER() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "SAVE_PLAYER");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_SAVE_PLAYER SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_SAVE_PLAYER Set_XP( long value )
		{
			request.AddNumber("XP", value);
			return this;
		}			
		public LogChallengeEventRequest_SAVE_PLAYER Set_POS( string value )
		{
			request.AddString("POS", value);
			return this;
		}
		public LogChallengeEventRequest_SAVE_PLAYER Set_GOLD( long value )
		{
			request.AddNumber("GOLD", value);
			return this;
		}			
	}
	
	public class LogEventRequest_Set_Pos : GSTypedRequest<LogEventRequest_Set_Pos, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_Set_Pos() : base("LogEventRequest"){
			request.AddString("eventKey", "Set_Pos");
		}
		public LogEventRequest_Set_Pos Set_POS( GSData value )
		{
			request.AddObject("POS", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_Set_Pos : GSTypedRequest<LogChallengeEventRequest_Set_Pos, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_Set_Pos() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "Set_Pos");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_Set_Pos SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_Set_Pos Set_POS( GSData value )
		{
			request.AddObject("POS", value);
			return this;
		}
		
	}
	
}
	

namespace GameSparks.Api.Messages {


}
