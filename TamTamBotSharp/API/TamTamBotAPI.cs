using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Queries;
using TamTamBot.API.Model;
using TamTamBot.API.Exceptions;

namespace TamTamBot.API
{
    public class TamTamBotAPI
    {
        #region Fields
        readonly TamTamClient client;
        #endregion

        #region Constructors
        public TamTamBotAPI(string accessToken, ITamTamTransportClient transport, ITamTamSerializer serializer) 
            : this(new TamTamClient(accessToken, transport, serializer))
        {

        }

        public TamTamBotAPI(TamTamClient client)
        {
            this.client = client;
        }

        public static TamTamBotAPI Create(string accessToken)
        {
            return new TamTamBotAPI(TamTamClient.Create(accessToken));
        }
        #endregion


        #region Methods
        /// <summary>
        /// Adds members to chat. Additional permissions may require.
        /// </summary>
        /// <param name="userIdsList">User IDs List (required)</param>
        /// <param name="chatId">Chat identifier (required)</param>
        /// <returns cref="AddMembersQuery"> Query to execute</returns>
        public AddMembersQuery AddMembers(UserIdsList userIdsList, long chatId)
        {
            if (userIdsList == null)
            {
                throw new RequiredParameterMissingException("Missing the required request body when calling addMembers");
            }

            if (chatId == 0)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'chatId' when calling addMembers");
            }

            return new AddMembersQuery(client, userIdsList, chatId);
        }

        /// <summary>
        /// This method should be called to send an answer after a user has clicked the button. 
        /// The answer may be an updated message or/and a one-time user notification.
        /// </summary>
        /// <param name="callbackAnswer">Callback answer (required)</param>
        /// <param name="callbackId">Identifies a button clicked by user. Bot receives this identifier after user pressed button as part of "MessageCallbackUpdate" (required)</param>
        /// <returns cref="AnswerOnCallbackQuery"> Query to execute</returns>
        public AnswerOnCallbackQuery AnswerOnCallback(CallbackAnswer callbackAnswer, string callbackId)
        {
            if (callbackId == null)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'callback_id' when calling answerOnCallback");
            }

            if (callbackAnswer == null)
            {
                throw new RequiredParameterMissingException("Missing the required request body when calling answerOnCallback");
            }

            return new AnswerOnCallbackQuery(client, callbackAnswer, callbackId);
        }

        /// <summary>
        /// Sends answer on construction request. Answer can contain any prepared message and/or keyboard to help user interact with bot.
        /// </summary>
        /// <param name="constructorAnswer">Constructor answer (required)</param>
        /// <param name="sessionId">Constructor session identifier (required)</param>
        /// <returns cref="ConstructQuery"> Query to execute</returns>
        public ConstructQuery Construct(ConstructorAnswer constructorAnswer, String sessionId)
        {
            if (sessionId == null)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'session_id' when calling construct");
            }

            if (constructorAnswer == null)
            {
                throw new RequiredParameterMissingException("Missing the required request body when calling construct");
            }

            return new ConstructQuery(client, constructorAnswer, sessionId);
        }


        /// <summary>
        /// Deletes message in a dialog or in a chat if bot has permission to delete messages.
        /// </summary>
        /// <param name="messageId">Deleting message identifier (required)</param>
        /// <returns cref="DeleteMessageQuery"> Query to execute</returns>
        public DeleteMessageQuery DeleteMessage(string messageId)
        {
            if (messageId == null)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'message_id' when calling deleteMessage");
            }

            return new DeleteMessageQuery(client, messageId);
        }


        /// <summary>
        /// Edits chat info: title, icon, etc…
        /// </summary>
        /// <param name="chatPatch">Chat patch (required)</param>
        /// <param name="chatId">Chat identifier (required)</param>
        /// <returns cref="EditChatQuery"> Query to execute</returns>
        public EditChatQuery EditChat(ChatPatch chatPatch, long chatId)
        {
            if (chatPatch == null)
            {
                throw new RequiredParameterMissingException("Missing the required request body when calling editChat");
            }

            if (chatId == 0)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'chatId' when calling editChat");
            }

            return new EditChatQuery(client, chatPatch, chatId);
        }

        /// <summary>
        /// Updated message should be sent as &#x60;NewMessageBody&#x60; in a request body.
        /// In case "attachments" field is "null", the current message attachments won’t be changed.
        /// In case of sending an empty list in this field, all attachments will be deleted.
        /// </summary>
        /// <param name="newMessageBody">New Message Body (required)</param>
        /// <param name="messageId">Editing message identifier (required)</param>
        /// <returns cref="EditMessageQuery"> Query to execute</returns>
        public EditMessageQuery EditMessage(NewMessageBody newMessageBody, string messageId)
        {
            if (messageId == null)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'message_id' when calling editMessage");
            }

            if (newMessageBody == null)
            {
                throw new RequiredParameterMissingException("Missing the required request body when calling editMessage");
            }

            return new EditMessageQuery(client, newMessageBody, messageId);
        }


        /// <summary>
        /// Edits current bot info. Fill only the fields you want to update. All remaining fields will stay untouched
        /// </summary>
        /// <param name="botPatch">Bot Patch (required)</param>
        /// <returns cref="EditMyInfoQuery"> Query to execute</returns>
        public EditMyInfoQuery EditMyInfo(BotPatch botPatch)
        {
            if (botPatch == null)
            {
                throw new RequiredParameterMissingException("Missing the required request body when calling editMyInfo");
            }

            return new EditMyInfoQuery(client, botPatch);
        }

        /// <summary>
        /// Returns all chat administrators. Bot must be **administrator** in requested chat.
        /// </summary>
        /// <param name="chatId">Chat identifier (required)</param>
        /// <returns cref="GetAdminsQuery"> Query to execute</returns>
        public GetAdminsQuery GetAdmins(long chatId)
        {
            if (chatId == 0)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'chatId' when calling getAdmins");
            }

            return new GetAdminsQuery(client, chatId);
        }


        /// <summary>
        /// Returns info about chat.
        /// </summary>
        /// <param name="chatId">Requested chat identifier (required)</param>
        /// <returns cref="GetChatQuery"> Query to execute</returns>
        public GetChatQuery GetChat(long chatId)
        {
            if (chatId == 0)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'chatId' when calling getChat");
            }

            return new GetChatQuery(client, chatId);
        }


        /// <summary>
        /// Returns chat/channel information by its public link or dialog with user by username
        /// </summary>
        /// <param name="chatLink">Public chat link or username (required)</param>
        /// <returns cref="GetChatByLinkQuery"> Query to execute</returns>
        public GetChatByLinkQuery GetChatByLink(String chatLink)
        {
            if (chatLink == null)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'chatLink' when calling getChatByLink");
            }

            return new GetChatByLinkQuery(client, chatLink);
        }

        /// <summary>
        /// Returns information about chats that bot participated in: a result list and marker points to the next page
        /// </summary>
        /// <returns cref="GetChatsQuery"> Query to execute</returns>
        public GetChatsQuery GetChats()
        {
            return new GetChatsQuery(client);
        }


        /// <summary>
        /// Returns users participated in chat.
        /// </summary>
        /// <param name="chatId">Chat identifier (required)</param>
        /// <returns cref="GetMembersQuery"> Query to execute</returns>
        public GetMembersQuery GetMembers(long chatId)
        {
            if (chatId == 0)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'chatId' when calling getMembers");
            }

            return new GetMembersQuery(client, chatId);
        }


        /// <summary>
        /// Returns chat membership info for current bot
        /// </summary>
        /// <param name="chatId">Chat identifier (required)</param>
        /// <returns cref="GetMembershipQuery"> Query to execute</returns>
        public GetMembershipQuery GetMembership(long chatId)
        {
            if (chatId == 0)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'chatId' when calling getMembership");
            }

            return new GetMembershipQuery(client, chatId);
        }

        /// <summary>
        /// Returns single message by its identifier.
        /// </summary>
        /// <param name="messageId">Message identifier ("mid") to get single message in chat (required)</param>
        /// <returns cref="GetMessageByIdQuery"> Query to execute</returns>
        public GetMessageByIdQuery GetMessageById(string messageId)
        {
            if (messageId == null)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'messageId' when calling getMessageById");
            }

            return new GetMessageByIdQuery(client, messageId);
        }


        /// <summary>
        /// Returns messages in chat: result page and marker referencing to the next page.
        /// Messages traversed in reverse direction so the latest message in chat will be first in result array.
        /// Therefore if you use "from" and "to" parameters, "to" must be **less than** "from"
        /// </summary>
        /// <returns cref="GetMessagesQuery"> Query to execute</returns>
        public GetMessagesQuery GetMessages()
        {
            return new GetMessagesQuery(client);
        }

        /// <summary>
        ///  Returns info about current bot. Current bot can be identified by access token.
        ///  Method returns bot identifier, name and avatar (if any)
        /// </summary>
        /// <returns cref="GetMyInfoQuery"> Query to execute</returns>
        public GetMyInfoQuery GetMyInfo()
        {
            return new GetMyInfoQuery(client);
        }

        /// <summary>
        /// Get pinned message in chat or channel.
        /// </summary>
        /// <param name="chatId">Chat identifier to get its pinned message (required)</param>
        /// <returns cref="GetPinnedMessageQuery"> Query to execute</returns>
        public GetPinnedMessageQuery GetPinnedMessage(long chatId)
        {
            if (chatId == null)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'chatId' when calling getPinnedMessage");
            }

            return new GetPinnedMessageQuery(client, chatId);
        }

        /// <summary>
        /// In case your bot gets data via WebHook, the method returns list of all subscriptions
        /// </summary>
        /// <returns cref="GetSubscriptionsQuery"> Query to execute</returns>
        public GetSubscriptionsQuery GetSubscriptions()
        {
            return new GetSubscriptionsQuery(client);
        }

        /// <summary>
        /// You can use this method for getting updates in case your bot is not subscribed to WebHook. 
        /// The method is based on long polling.  Every update has its own sequence number. "marker" property
        /// in response points to the next upcoming update.  All previous updates are considered as *committed*
        /// after passing "marker" parameter. If "marker" parameter is **not passed**, your bot will get all 
        /// updates happened after the last commitment.
        /// </summary>
        /// <returns cref="GetUpdatesQuery"> Query to execute</returns>
        public GetUpdatesQuery GetUpdates()
        {
            return new GetUpdatesQuery(client);
        }

        /// <summary>
        /// Returns the URL for the subsequent file upload.  For example, you can upload it via curl:
        /// curl -i -X POST -H "Content-Type: multipart/form-data" -F "data&#x3D;@movie.mp4" "%UPLOAD_URL%"  
        /// Two types of an upload are supported: - single request upload (multipart request) - and resumable upload.
        /// Multipart upload This type of upload is a simpler one but it is less reliable and agile. 
        /// If a Content-Type: multipart/form-data header is passed in a request our service indicates upload type as a 
        /// simple single request upload.  This type of an upload has some restrictions:
        /// - Max. file size - 2 Gb - Only one file per request can be uploaded 
        /// - No possibility to restart stopped / failed upload  
        /// ##### Resumable upload If Content-Type header value is not equal to multipart/form-data our 
        /// service indicated upload type as a resumable upload. With a Content-Range header current file 
        /// chunk range and complete file size can be passed. If a network error has happened or upload was 
        /// stopped you can continue to upload a file from the last successfully uploaded file chunk. 
        /// You can request the last known byte of uploaded file from server and continue to upload a file.  
        /// ##### Get upload status To GET an upload status you simply need to perform HTTP-GET request to a file upload URL. 
        /// Our service will respond with current upload status, complete file size and last known uploaded byte. 
        /// This data can be used to complete stopped upload if something went wrong. If REQUESTED_RANGE_NOT_SATISFIABLE or INTERNAL_SERVER_ERROR
        /// status was returned it is a good point to try to restart an upload
        /// </summary>
        /// <param name="type">Uploaded file type: photo, audio, video, file (required)</param>
        /// <returns cref="GetUploadUrlQuery"> Query to execute</returns>
        public GetUploadUrlQuery GetUploadUrl(UploadTypes type)
        {
            if (type == null)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'type' when calling getUploadUrl");
            }

            return new GetUploadUrlQuery(client, type);
        }

        /// <summary>
        /// Removes bot from chat members.
        /// </summary>
        /// <param name="chatId">Chat identifier (required)</param>
        /// <returns cref="LeaveChatQuery"> Query to execute</returns>
        public LeaveChatQuery LeaveChat(long chatId)
        {
            if (chatId == 0)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'chatId' when calling leaveChat");
            }

            return new LeaveChatQuery(client, chatId);
        }

        /// <summary>
        /// Pins message in chat or channel.
        /// </summary>
        /// <param name="pinMessageBody">Pin Message Body (required)</param>
        /// <param name="chatId">Chat identifier where message should be pinned (required)</param>
        /// <returns cref="PinMessageQuery"> Query to execute</returns>
        public PinMessageQuery PinMessage(PinMessageBody pinMessageBody, long chatId)
        {
            if (pinMessageBody == null)
            {
                throw new RequiredParameterMissingException("Missing the required request body when calling pinMessage");
            }

            if (chatId == 0)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'chatId' when calling pinMessage");
            }

            return new PinMessageQuery(client, pinMessageBody, chatId);
        }


        /// <summary>
        /// Removes member from chat. Additional permissions may require.
        /// </summary>
        /// <param name="chatId">Chat identifier (required)</param>
        /// <param name="userId">User id to remove from chat (required)</param>
        /// <returns cref="RemoveMemberQuery"> Query to execute</returns>
        public RemoveMemberQuery RemoveMember(long chatId, long userId)
        {
            if (userId == 0)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'user_id' when calling removeMember");
            }

            if (chatId == 0)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'chatId' when calling removeMember");
            }

            return new RemoveMemberQuery(client, chatId, userId);
        }

        /// <summary>
        /// Send bot action to chat
        /// </summary>
        /// <param name="actionRequestBody"> Action Request Body (required)</param>
        /// <param name="chatId">Chat identifier (required)</param>
        /// <returns cref="SendActionQuery"> Query to execute</returns>
        public SendActionQuery SendAction(ActionRequestBody actionRequestBody, long chatId)
        {
            if (actionRequestBody == null)
            {
                throw new RequiredParameterMissingException("Missing the required request body when calling sendAction");
            }

            if (chatId == null)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'chatId' when calling sendAction");
            }

            return new SendActionQuery(client, actionRequestBody, chatId);
        }

        /// <summary>
        /// Sends a message to a chat. As a result for this method new message identifier returns.
        /// ### Attaching media Attaching media to messages is a three-step process. 
        /// At first step, you should [obtain a URL to upload](#operation/getUploadUrl) your media files.
        /// At the second, you should upload binary of appropriate format to URL you obtained at the previous step.
        /// See [upload](https://dev.tamtam.chat/#operation/getUploadUrl) section for details.
        /// Finally, if the upload process was successful, you will receive JSON-object in a response body.
        /// Use this object to create attachment. Construct an object with two properties: - &#x60;type&#x60; 
        /// with the value set to appropriate media type - and &#x60;payload&#x60; 
        /// filled with the JSON you&#39;ve got.  For example, you can attach a video to message this way: 
        /// 1. Get URL to upload. Execute following: 
        /// shell curl -X POST https://botapi.tamtam.chat/uploads?access_token&#x3D;%access_token%&amp;type&#x3D;video&#39;
        /// As the result it will return URL for the next step.
        /// json {"url": "http://vu.mycdn.me/upload.do…" }
        /// 2. Use this url to upload your binary: shell curl -i -X POST -H 
        /// "Content-Type: multipart/form-data" -F "data&#x3D;@movie.mp4" "http://vu.mycdn.me/upload.do…" 
        /// As the result it will return JSON you can attach to message: 
        /// json   {"token": "_3Rarhcf1PtlMXy8jpgie8Ai_KARnVFYNQTtmIRWNh4"   };
        /// 3. Send message with attach:
        /// json {"text": "Message with video", "attachments": [{"type": "video","payload":{"token": "_3Rarhcf1PtlMXy8jpgie8Ai_KARnVFYNQTtmIRWNh4"}}]}
        /// **Important notice**:  It may take time for the server to process your file (audio/video or any binary). 
        /// While a file is not processed you can't attach it. It means the last step will fail with error.
        /// Try to send a message again until you'll get a successful result.
        /// </summary>
        /// <param name="newMessageBody">New Message Body (required)</param>
        /// <returns cref="SendMessageQuery"> Query to execute</returns>
        public SendMessageQuery SendMessage(NewMessageBody newMessageBody)
        {
            if (newMessageBody == null)
            {
                throw new RequiredParameterMissingException("Missing the required request body when calling sendMessage");
            }

            return new SendMessageQuery(client, newMessageBody);
        }

        /// <summary>
        /// Subscribes bot to receive updates via WebHook. After calling this method, the bot will receive notifications about new events in chat rooms at the specified URL.  
        /// Your server **must** be listening on one of the following ports: **80, 8080, 443, 8443, 16384-32383**
        /// </summary>
        /// <param name="subscriptionRequestBody">SubscriptionRequestBody  (required)</param>
        /// <returns cref="SubscribeQuery"> Query to execute</returns>
        public SubscribeQuery Subscribe(SubscriptionRequestBody subscriptionRequestBody)
        {
            if (subscriptionRequestBody == null)
            {
                throw new RequiredParameterMissingException("Missing the required request body when calling subscribe");
            }

            return new SubscribeQuery(client, subscriptionRequestBody);
        }

        /// <summary>
        /// Unpins message in chat or channel.
        /// </summary>
        /// <param name="chatId">Chat identifier to remove pinned message (required)</param>
        /// <returns cref="UnpinMessageQuery"> Query to execute</returns>
        public UnpinMessageQuery UnpinMessage(long chatId)
        {
            if (chatId == null)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'chatId' when calling unpinMessage");
            }

            return new UnpinMessageQuery(client, chatId);
        }


        /// <summary>
        /// Unsubscribes bot from receiving updates via WebHook. After calling the method, the bot stops receiving notifications about new events. 
        /// Notification via the long-poll API becomes available for the bot
        /// </summary>
        /// <param name="url">URL to remove from WebHook subscriptions (required)</param>
        /// <returns cref="UnsubscribeQuery"> Query to execute</returns>
        public UnsubscribeQuery Unsubscribe(string url)
        {
            if (url == null)
            {
                throw new RequiredParameterMissingException("Missing the required parameter 'url' when calling unsubscribe");
            }

            return new UnsubscribeQuery(client, url);
        }
        #endregion
    }
}
